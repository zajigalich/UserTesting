#!/bin/bash

# This commands required to be run once inside minikube so non-root user can create folder for hostPath volume
# sudo mkdir -p /data/ms-sql
# sudo chmod -R 777 /data/ms-sql

SQL_DEPLOYMENT="sql-deployment.yaml"
SQL_SERVICE="sql-service.yaml"
API_DEPLOYMENT="api-deployment.yaml"
API_SERVICE="api-service.yaml"

function start_minikube {
    minikube start --driver=docker
    
    eval $(minikube docker-env)

    docker build -t api:latest .
    docker pull mcr.microsoft.com/mssql/server:2022-latest

    kubectl apply -f $SQL_DEPLOYMENT
    kubectl apply -f $SQL_SERVICE
    kubectl apply -f $API_DEPLOYMENT
    kubectl apply -f $API_SERVICE

    echo "Waiting for pods to stabilize..."
    
    sleep 2s
    
    kubectl get pods -o wide
}

function stop_minikube {
    kubectl delete -f $API_DEPLOYMENT
    kubectl delete -f $API_SERVICE
    kubectl delete -f $SQL_DEPLOYMENT
    kubectl delete -f $SQL_SERVICE

    minikube stop
}

function service_url {
    minikube service api-service --url
}

# Command-line argument handling
case "$1" in
    -start|-st)
        start_minikube
        ;;
    -stop|-sp)
        stop_minikube
        ;;
    -url|-u)
        service_url
        ;;
    *)
        echo "Invalid usage!"
        echo "Usage: -start|-st to start services"
        echo "       -stop|-sp to stop and delete services"
        echo "       -url|-u to get the URL of the API service"
        ;;
esac
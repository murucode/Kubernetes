# Steps to deploy in azure

## Using azure portal to create cluster
- Create a resource group in azure
- Create a aks cluster with default config. use single node for developement purpose.

## Manage cluster using azure cli
- login using azure cli
    ```sh
    az login
    ```
- To View default subscribtion 
    ```sh
    az account show --output table
    ```
- To change subscribtion
    ```sh
    az account set --subscription "Another subscribtion"
    ```
- Create Azure Container Registry using portal
- To link AKS cluster with ACR 
    ```sh
    az aks update -n myAKSCluster -g myResourceGroup --attach-acr <acr-name>
    ```
- To push imag from local machine
    ```sh
    az acr login --name <acrname>
    docker build -t <acrname>.azurecr.io/hello-world:v1 .
    docker push <acrname>.azurecr.io/hello-world:v1
    ```
- To create kubernetes service
    ```sh
    kubectl apply -f service.yaml
    ```
- To create ingress
    ```sh
    kubectl apply -f ingress.yaml
    az aks show -g $RESOURCE_GROUP -n $CLUSTER_NAME -o tsv --query addonProfiles.httpApplicationRouting.config.HTTPApplicationRoutingZoneName
    kubectl get ingress
    ```    

Reference: https://docs.microsoft.com/en-us/learn/modules/aks-deploy-container-app/

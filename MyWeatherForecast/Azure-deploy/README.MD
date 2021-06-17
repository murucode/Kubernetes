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

## Simple Deployment

- Create Resource group and cluster

```sh
RESOURCE_GROUP=rg-contoso-video
CLUSTER_NAME=aks-contoso-video
```

```sh
az group create --name $RESOURCE_GROUP --location eastus
```

```sh
az aks create \
    --resource-group $RESOURCE_GROUP \
    --name $CLUSTER_NAME \
    --node-count 1 \    
    --enable-managed-identity \
    --generate-ssh-keys \
    --node-vm-size Standard_B2s
```

- Get credentials to access aks from azure cli. This will create .kube folder and store the cluster connection setting in user profile.

```sh
az aks get-credentials --name $CLUSTER_NAME --resource-group $RESOURCE_GROUP

```

- Deploy resources

```sh
kubectl apply -f azure-vote.yaml
```

- Get external IP from the output of the following command. Use this IP to access voting app.

```sh
kubectl get service azure-vote-front --watch
```

- Delete cluster

```sh
az aks delete --resource-group myResourceGroup --name myAKSCluster --no-wait
```

Reference:
<https://docs.microsoft.com/en-us/learn/modules/aks-deploy-container-app/>
<https://docs.microsoft.com/en-in/azure/aks/kubernetes-walkthrough-portal>

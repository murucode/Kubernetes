# Sample forecast app in minikube

Steps:

1. Build Image

   - Set the environment variables with the following to use minikube as your docker daemon

     ```sh
         eval $(minikube docker-env)
     ```

   - Build the image with the Docker daemon of Minikube (eg docker build -t myweatherforecast .)
   - Set the image in the pod spec like the build tag (eg myweatherforecast)
   - Set the imagePullPolicy to Never, otherwise Kubernetes will try to download the image.
   - Important note: You have to run eval $(minikube docker-env) on each terminal you want to use, since it only sets the environment variables for the current shell session.

2. Run the deployment.yaml in inside kube folder

   ```sh
   kubectl create -f deployment.yaml
   ```

3. Run service-def.yaml

   ```sh
   kubectl create -f service-def.yaml
   ```
```sh
az aks update -n myAKSCluster -g myResourceGroup --attach-acr <acr-name>

```
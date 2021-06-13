# Kubernetes commands

Starts the driver in vm or hyper v

```sh
minkube start —driver=virtualbox/hyperv
```

Delete the minikube from your machine

```sh
minikube delete —all/—purge
```

Kubectl commands

```sh
kubectl version

kubectl get pods -o wide

kubectl create deployment nginx-muru1 --image=nginx

kubectl expose deployment nginx-muru2 --type=NodePort --port=8080

kubectl run nginx-muru —image=nginx
```

Pod Commands

```sh
kubectl create -f pod-def.yaml

kubectl apply -f pod-def.yaml

kubectl describe pod nginx-muru
```

Replicate controllers

```sh
kubectl create -f rc-definition.yaml

kubect get replicationcontroller

kubectl delete replicationcontroller name
```

Replica set

```sh
kubectl create -f rep-set-defin.yaml

kubectl get replicaset

kubetrl delete replicaset name #deletes replicaset and also the pods

kubectl replace -f replicaset rep-set-def.yaml

kubetctl scale --replicas=6 -f replicaset 'rep-name'

kubectl edit replicaset 'replicaset name'
```

Delpoyment

```sh
kubectl get all

kubectl create -f deploy-def.yaml --record

kubectl edit deployment 'deployment name' --record

kubect set image deployment 'deployment name' nginx=nginx1.24 --record
```

Servicess

```sh
kubectl create -f service-def.yaml

kubectl get svc

minikube service 'my-service' --url
```

So to use an image without uploading it, you can follow these steps:

Set the environment variables with eval $(minikube docker-env)
Build the image with the Docker daemon of Minikube (eg docker build -t my-image .)
Set the image in the pod spec like the build tag (eg my-image)
Set the imagePullPolicy to Never, otherwise Kubernetes will try to download the image.
Important note: You have to run eval $(minikube docker-env) on each terminal you want to use, since it only sets the environment variables for the current shell session.

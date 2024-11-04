#### How to run locally

```shell
dotnet test --settings .runsettings
```

### How to run it in docker

```shell
# Build the image
docker build -t test-framework -f .Dockerfile . 

# Run the container
docker run --name my-test-container test-framework 

# See the logs
docker logs my-test-container

# Remove the container
docker rm /my-test-container 

# Remove the image
docker rmi test-framework 
```
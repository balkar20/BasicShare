1)To check container network , IP etc:
docker inspect c1 -f "{{json .NetworkSettings.Networks }}"
2) In Grafana and when runnuing apps from docker to set loki and other urls use pattern: loki:3100
3) To Test Application using exteral docker environment without our custom applications: "docker-compose up" command to 
docker-compose-env.yml (docker-compose -f docker-compose-env.yml up)
file which contains postgres, redis, rabbit, grafana, loki
to start docker environment for application 
1.  create image
2. dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer
    Login
docker login --username username 
docker login -u="${DOCKER_LOGIN}" -p="${DOCKER_PASSWORD}"
    push it to hub
docker tag 50acceeb2c457fd45be2f3dd7c9859[it is image id] balkar20/productwebapi
docker push balkar20/productwebapi:latest
2. 


docker run --name jenkins-docker --rm --detach
  --privileged --network jenkins --network-alias docker
  --env DOCKER_TLS_CERTDIR=/certs
  --volume jenkins-docker-certs:/certs/client
  --volume jenkins-data:/var/jenkins_home
  --publish 2376:2376
  docker:dind
  
  DockerFile:
  FROM jenkins/jenkins:2.401.1
USER root
RUN apt-get update && apt-get install -y lsb-release
RUN curl -fsSLo /usr/share/keyrings/docker-archive-keyring.asc \
  https://download.docker.com/linux/debian/gpg
RUN echo "deb [arch=$(dpkg --print-architecture) \
  signed-by=/usr/share/keyrings/docker-archive-keyring.asc] \
  https://download.docker.com/linux/debian \
  $(lsb_release -cs) stable" > /etc/apt/sources.list.d/docker.list
RUN apt-get update && apt-get install -y docker-ce-cli
USER jenkins
RUN jenkins-plugin-cli --plugins "blueocean docker-workflow"

  docker build -t myjenkins-blueocean:2.401.1-1 .

  docker run --name jenkins-blueocean --restart=on-failure --detach ^
  --network jenkins --env DOCKER_HOST=tcp://docker:2376 ^
  --env DOCKER_CERT_PATH=/certs/client --env DOCKER_TLS_VERIFY=1 ^
  --volume jenkins-data:/var/jenkins_home ^
  --volume jenkins-docker-certs:/certs/client:ro ^
  --publish 8080:8080 --publish 50000:50000 myjenkins-blueocean:2.401.1-1


Environments:
  DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
  DOCKER_LOGIN=balkar20
  DOCKER_-PASSWORD=PASS


  Steps with .net sdk plugin 
1/Build for sln 
2/test
3/publish with linux-x64
4/ publish to dockerhub:
ADD STEP WITH shell command:
docker login -u="${DOCKER_LOGIN}" -p="${DOCKER_PASSWORD}"
docker tag productwebapi:1.1.0 balkar20/productwebapi
docker push balkar20/productwebapi:latest

Front -- left stick navbar ====>Drawer mudblazor
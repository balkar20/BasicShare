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
    push it to hub
docker tag 50acceeb2c457fd45be2f3dd7c9859[it is image id] balkar20/productwebapi
docker push balkar20/productwebapi:latest
2. 
  
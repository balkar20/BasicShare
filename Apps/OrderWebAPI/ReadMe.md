1)To check container network , IP etc:
docker inspect c1 -f "{{json .NetworkSettings.Networks }}"
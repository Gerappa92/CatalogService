To make Identity Server enabled run following command:

`docker run -d -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin --name mentoring-identity-server quay.io/keycloak/keycloak:21.1.1 start-dev`
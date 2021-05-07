# Adventureworks Database Setup

The scripts and Docker files in this directory exist to support development
work by enabling easy platform-agnostic spinning up of databases to test
against. Steps:

1. Open your terminal of choice
2. `cd` to the current directory
3. `docker-compose build`
4. `docker-compose up -d`
5. Connect to the instance using `.,1401` as the server. The username and
password can be set/found in [docker-compose.yml](docker-compose.yml)

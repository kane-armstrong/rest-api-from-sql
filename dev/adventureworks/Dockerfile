FROM alpine:3.7 as build
RUN wget https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2019.bak -O adventureworks.bak -q

FROM mcr.microsoft.com/mssql/server:2019-latest AS run
ARG SA_PASSWORD
ENV SA_PASSWORD=${SA_PASSWORD}
EXPOSE 1433
WORKDIR /
COPY --from=build adventureworks.bak adventureworks.bak
COPY ./restore.sql .
COPY ./restore.sh .
COPY ./start.sh .
CMD /bin/bash ./start.sh

pipeline {
    agent any
    options {
        buildDiscarder(logRotator(artifactDaysToKeepStr: '2', numToKeepStr: '5'))
        disableConcurrentBuilds()
    }
    stages {
        stage('Clean') {
            steps {
                sh 'dotnet clean'
            }
        }
        stage('Restore packages') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
    }
}
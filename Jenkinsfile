pipeline {
    agent any
    tools {
        dotnet 'dotnet-7.0.7'
    }

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                sh "dotnet build"
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}

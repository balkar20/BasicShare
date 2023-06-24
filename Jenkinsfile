pipeline {
    agent any

    environment {
    PATH = "$HOME/.dotnet"
}
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                withDotNet(
                    sdk: '/root/.dotnet/sdk/7.0.305'
                ){
                    sh 'dotnet build'
                }
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

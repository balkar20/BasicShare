pipeline {
    agent any

    environment {
    PATH = "$PATH:$HOME/.dotnet"
    }
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                 sh 'export PATH="$PATH:$HOME/.dotnet"'
                withDotNet(
                    sdk: '7.0.100'
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

pipeline {
    agent any

    environment {
    PATH = "$HOME/.dotnet"
}
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                echo pwd()
                sh 'export PATH="$PATH:$HOME/.dotnet"'
                echo dotnet --list-sdks()
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

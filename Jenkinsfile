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

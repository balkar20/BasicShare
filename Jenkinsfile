pipeline {
    agent any
    tools{
        dotnetsdk
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

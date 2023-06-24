pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                withDotNet(){
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

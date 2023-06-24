pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                withDotNet("dotnetBuild")
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

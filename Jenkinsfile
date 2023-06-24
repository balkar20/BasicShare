pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                sh(script: "dotnet bild StartupToolTemplate.sln")
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

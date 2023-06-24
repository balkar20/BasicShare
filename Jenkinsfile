pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                withDotNet(
                    sdk: '/home/user/.dotnet/sdk/7.0.305'
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

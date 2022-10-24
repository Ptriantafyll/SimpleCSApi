pipeline {
    agent any
    stages {
        stage ('Build Docker Image'){
            steps {
                sh 'docker build -t ptriantafyll/simplecsapi .'
            }
        }
        stage ('Run Docker Image'){
            steps{
                sh 'docker run -p 8000:80 ptriantafyll/simplecsapi'
            }
        }
    }
}

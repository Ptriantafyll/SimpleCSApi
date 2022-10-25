pipeline {
    environment {
        registry = "prtiantafyll/simplecsapi"
        registryCredential = 'ptriantafyll'
        dockerImage = ''
    }
    agent any
    stages {
        // stage ('Build Docker Image'){
        //     steps {
        //         sh 'docker build -t ptriantafyll/simplecsapi .'
        //     }
        // }
        // stage ('Run Docker Image'){
        //     steps{
        //         sh 'docker run -p 8000:80 ptriantafyll/simplecsapi'
        //     }
        // }
        stage ('Build Docker Image') {
            steps {
                script {
                    dockerImage = docker.build registry
                }
            }
        }
        stage("Deploy out image") {
            steps {
                script {
                        docker.withRegistry('', registryCredential ) {
                        dockerImage.push()
                    }
                }
            }
        }
        stage("Clean up") {
            steps {
                sh "docker rmi $registry"
            }
        }
    }
}

pipeline {
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
        stage('Docker Build') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/main']], extensions: [], userRemoteConfigs: [[credentialsId: '<snip>', url: 'https://github.com/Ptriantafyll/SimpleCSApi']]])

                container('docker') {
                    sh "docker build -t ptriantafyll/simplecsapi ."
                }
            }
        }
    }
}

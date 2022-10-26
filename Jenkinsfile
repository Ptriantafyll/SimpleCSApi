pipeline {
    agent any
    stages {
        stage('Docker Build') {
            steps {
                container('docker') {
                    sh "docker build -t ptriantafyll/simplecsapi ."
                }            
            }
        }
    }
}

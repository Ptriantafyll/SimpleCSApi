pipeline {
    agent any
    
    environment {
		DOCKERHUB_CREDENTIALS=credentials('dockerhub-credentials-ptriantafyll')
	}
    
    stages {
        stage('Git Checkout'){
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/main']], userRemoteConfigs: [[url: 'https://github.com/Ptriantafyll/SimpleCSApi/']]])
            }
        }
        stage('Docker Build') {
            steps {
                sh "docker build -t ptriantafyll/simplecsapi ."
            }
        }
        stage('Docker Login'){
            steps {
				sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
			}
        }
        stage('Push to docker hub'){
            steps{
                sh "docker push ptriantafyll/simplecsapi"
            }
        }
    }
    
    post {
		always {
			sh 'docker logout'
		}
	}
}

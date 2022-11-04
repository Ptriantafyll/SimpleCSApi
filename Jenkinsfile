pipeline {
    agent any
    
    environment {
		DOCKERHUB_CREDENTIALS=credentials('dockerhub-credentials-ptriantafyll')
	}
    
    stages {
        stage('Git Checkout'){
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/jenkins-docker-testing']], userRemoteConfigs: [[url: 'https://github.com/Ptriantafyll/SimpleCSApi/']]])
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
        stage('Deploy to Kubernetes cluster'){
            steps {
                kubeconfig(credentialsId: 'kubernetes', serverUrl: 'https://kubernetes.docker.internal:6443', caCertificate: '') {
                    // kubernetesApply file: './k8s/api-deployment.yaml', createNewResources: true, deletePodsOnReplicationControllerUpdate: false, ignoreRunningOAuthClients: false, ignoreServices: false, processTemplatesLocally: false, readinessTimeout: 0, rollingUpgradePreserveScale: true, rollingUpgrades: true, environment: '', environmentName: '', registry: 'ptriantafyll/simplecsapi', servicesOnly: false
                    // kubernetesApply file: './k8s/api-nodeport.yaml', createNewResources: true, deletePodsOnReplicationControllerUpdate: false, ignoreRunningOAuthClients: false, ignoreServices: false, processTemplatesLocally: false, readinessTimeout: 0, rollingUpgradePreserveScale: true, rollingUpgrades: true, environment: '', environmentName: '', registry: 'ptriantafyll/simplecsapi', servicesOnly: false
                    // kubernetesApply(file: '/k8s/api-nodeport.yaml', createNewResources: true, deletePodsOnReplicationControllerUpdate: false, ignoreRunningOAuthClients: false, ignoreServices: false, processTemplatesLocally: false, readinessTimeout: 0, rollingUpgradePreserveScale: true, rollingUpgrades: true, servicesOnly: false)
                    // kubernetesApply(file: '/k8s/api-deployment.yaml', createNewResources: true, deletePodsOnReplicationControllerUpdate: false, ignoreRunningOAuthClients: false, ignoreServices: false, processTemplatesLocally: false, readinessTimeout: 0, rollingUpgradePreserveScale: true, rollingUpgrades: true, servicesOnly: false)
                    sh 'kubectl apply -f ./k8s/'
                }
            }
        }
    }
    
    post {
		always {
			sh 'docker logout'
		}
	}
}

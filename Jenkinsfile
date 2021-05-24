pipeline {
    agent any
    stages {
        stage ("Build"){
            steps {
                parallel(
                    web: {
                        dir("web") {
                            sh "docker build -t christensenkim/devopscalc-web:${BUILD_NUMBER} ."
                        }
                    },
                    api: {
                        dir("api") {
                            sh "dotnet build devops-calculator-api.sln"
                            sh "docker build -t christensenkim/devopscalc:${BUILD_NUMBER} ."
                        }
                    },
                    db: {
                        dir("") {
                            sh "docker-compose up -d"
                        }
                    }
                )
            }
        }

        stage("Test API") {
            steps {
                sh "dotnet test XUnitTestCalculator/XUnitTestCalculator.csproj"
            }
        }
        stage("Deliver Web") {
            steps {
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'docker-devopscalc', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push christensenkim/devopscalc-web:${BUILD_NUMBER}"
            }
        }
        stage("Deliver API") {
            steps {
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'docker-devopscalc', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push christensenkim/devopscalc:${BUILD_NUMBER}"
            }
        }
        stage("Release to test") {
            steps {
                sh "docker-compose pull"
				sh "docker-compose -p test -f docker-compose.yml -f docker-compose.test.yml up -d"
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
pipeline {
    agent any
    stages {
        stage ("Build"){
            steps {
                parallel(
                    web: {
                        dir("web") {
                            sh "docker build . -t christensenkim/devopscalc-web:${BUILD_NUMBER}"
                        }
                    },
                    api: {
                        dir("api") {
                            sh "dotnet build"
                            sh "docker build . -t christensenkim/devopscalc:${BUILD_NUMBER}"
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
        stage("Release staging environment") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
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
                            // sh "docker-compose up -d"
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
				sh "docker-compose -p test -f docker-compose.yml -f docker-compose.test.yml up -d"
            }
        }
        stage("Selenium grid") {
            steps {
                sh "docker network create SE"
                sh "docker run -d --rm -p 4444:4444 --net=SE --name selenium-hub selenium/hub"
                sh "docker run -d --rm --net=SE -e HUB_HOST=selenium-hub --name selenium-node-firefox selenium/node-firefox"
                sh "docker run -d --rm --net=SE -e HUB_HOST=selenium-hub --name selenium-node-chrome selenium/node-chrome"
                sh "docker run -d --rm --net=SE --name app-test-container christensenkim/devopscalc"
            }
        }
        stage("Execute selenium") {
            steps {
                sh "selenium-side-runner --server http://185.51.76.19:25002/wd/hub -c 'browserName=firefox' --base-url http://app-test-container test/system/Devops-Calculator.side"
                sh "selenium-side-runner --server http://185.51.76.19:25002/wd/hub -c 'browserName=chrome' --base-url http://app-test-container test/system/Devops-Calculator.side"
            }
        }
    }
    post {
        cleanup {
            sh script:"docker stop selenium-hub", returnStatus:true
            sh script:"docker stop selenium-node-firefox", returnStatus:true
            sh script:"docker stop selenium-node-chrome", returnStatus:true
            sh script:"docker stop app-test-container", returnStatus:true
            sh script:"docker network remove SE", returnStatus:true
        }
    }
}
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
                        dir(.) {
                            sh "docker-compose up -d"
                        }
                    }
                )
            }
        }

        stage("Test API") {
            steps {
                echo "===== REQUIRED: Will execute unit tests of the API project ====="
            }
        }
        stage("Deliver Web") {
            steps {
                echo "===== REQUIRED: Will deliver the website to Docker Hub ====="
            }
        }
        stage("Deliver API") {
            steps {
                echo "===== REQUIRED: Will deliver the API to Docker Hub ====="
            }
        }
        stage("Release staging environment") {
            steps {
                echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
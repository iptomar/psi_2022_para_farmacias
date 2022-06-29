# psi_2022_para_farmacias

## How to Deploy
/psi_2022_para_farmacia

heroku container:login

docker build -f parafarmacia/Dockerfile . -t prod

docker tag prod registry.heroku.com/parafarmacia/web        

docker push registry.heroku.com/parafarmacia/web    

heroku container:release web -a parafarmacia


Url:  https://parafarmacia.herokuapp.com/

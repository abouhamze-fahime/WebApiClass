function login(username, password){

    fetch("http://localhost:1421/api/Authetication", {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: "{'username':'"+username+"','password':'"+password+"'}"
      })
        .then((res) => {
            if(res.status>=400){
                alert(res.statusText);
            }
            else{
                debugger;
                alert('Welcome '+username);
            }
        })
        .catch(error => console.error('Unable to add item.', error));
}
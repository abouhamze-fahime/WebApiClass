function logout(){

    fetch("http://localhost:1421/api/Authetication", {
        method: 'PUT',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
          'Token':'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InZhaGlkIiwibmJmIjoxNTk3NTExNDM0LCJleHAiOjE1OTc1MTI2MzQsImlhdCI6MTU5NzUxMTQzNH0.VHLAs3wZGosDT3-B5aWEyVvxEAwZ3cKzMz3k9Tg3PDw'
        }
      })
        .then((res) => {
            if(res.status>=400){
                alert(res.statusText);
            }
            else{
                window.location="login.html";
            }
        })
        .catch(error => console.error('Unable to logout.', error));
}
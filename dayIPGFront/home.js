function logout(){

    fetch("http://localhost:1421/api/Authetication", {
        method: 'PUT',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
          'Token':'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InZhaGlkIiwibmJmIjoxNTk3NTk4NTE4LCJleHAiOjE1OTc1OTk3MTgsImlhdCI6MTU5NzU5ODUxOH0.UTkvKJ3_qKH6PEiJAEUxgYUYc-Kb16kqguQJRkcMasE'
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
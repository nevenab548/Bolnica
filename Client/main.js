import {Bolnica} from "./bolnica.js"

/*fetch("https://localhost:5001/Bolnica/PreuzmiBolnice").then(p=>{
    p.json().then(data=>{
        data.forEach(bolnica =>{
            const bolnica1=new Bolnica(bolnica.naziv,bolnica.BrojSoba,bolnica.KapacitetSobe,bolnica.BrojSmena);
            bolnica1.crtajBolnicu(document.body);

            bolnica.sobe.forEach(soba=>{
                var sob =bolnica1.sobe[soba.brojSobe-1];
                if(soba.maxPrimljeni >= soba.primljeni+sob.primljeni)
                {
                    sob.azurirajLokaciju(soba.pa)
                }
            });
        })
    })
});*/
const bolnica1=new Bolnica("KBC-Zvezdara",20,4,18);
bolnica1.crtajBolnicu(document.body);

/*const bolnica2=new Bolnica("Amsterdam",17,2,10,3);
bolnica2.crtajBolnicu(document.body);*/
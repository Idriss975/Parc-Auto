using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcAuto.Classes_Globale
{
    class BigStrings
    {
        public static string SQLdgvVehicules =
            @"declare @Vehicules_Table table 
(
	Matricule int, 
	Marque varchar(50), 
	Modele varchar(50), 
	Couleur varchar(50),
	MiseEnCirculation date,
	Carburant varchar(50),
	Observation varchar(max),
	Conducteur int,
	Nom varchar(50),
	Prenom varchar(50)
)

declare Vehicules_Cursor CURSOR for select Vehicules.*, Nom, Prenom from Vehicules, Conducteurs where Vehicules.Conducteur = Conducteurs.Matricule
declare @Mat int, @Marq varchar(50), @Modle varchar(50), @Coul varchar(50),@MiseEnCir date,@Carb varchar(50), @Obser varchar(max),@ID int,@N varchar(50),@P varchar(50);

Open Vehicules_Cursor
FETCH NEXT FROM Vehicules_Cursor INTO @Mat, @Marq, @Modle, @Coul,@MiseEnCir,@Carb,@Obser,@ID, @N, @P;



WHILE @@FETCH_STATUS = 0  
BEGIN  
	insert into  @Vehicules_Table values (@Mat, @Marq, @Modle, @Coul,@MiseEnCir,@Carb,@Obser,@ID,@N,@P);
	FETCH NEXT FROM Vehicules_Cursor INTO @Mat, @Marq, @Modle, @Coul,@MiseEnCir,@Carb,@Obser,@ID, @N, @P;
END
CLOSE Vehicules_Cursor;  
DEALLOCATE Vehicules_Cursor;  


declare Vehicules_Cursor CURSOR for select Vehicules.Matricule, Marque, Modele,	Couleur, MiseEnCirculation, Carburant, Observation from Vehicules, Conducteurs where Vehicules.Conducteur is null

Open Vehicules_Cursor
FETCH NEXT FROM Vehicules_Cursor INTO @Mat, @Marq, @Modle, @Coul,@MiseEnCir,@Carb,@Obser;



WHILE @@FETCH_STATUS = 0  
BEGIN  
	insert into @Vehicules_Table values (@Mat, @Marq,@Modle, @Coul,@MiseEnCir,@Carb,@Obser,null,'Sans','Conducteur');
	FETCH NEXT FROM Vehicules_Cursor INTO @Mat, @Marq, @Modle, @Coul,@MiseEnCir,@Carb,@Obser;
END
CLOSE Vehicules_Cursor;  
DEALLOCATE Vehicules_Cursor;  

Select distinct * from @Vehicules_Table;";
    }
}

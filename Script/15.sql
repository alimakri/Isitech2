
use BD1;

IF @i=1
  BEGIN
  select * from ..
  END
ELSE
  BEGIN
  END




Exec EditVille '
	<villes>
		<ville op="Ajout" nom="Strasbourg"/> 
		<ville op="Suppression" nom="Paris"/> 
		<ville op="Modif" id="2" nom="Sete"/> 
		<ville op="Modif" id="1" nom="Grenoble"/> 
	</villes>'
select * from Ville

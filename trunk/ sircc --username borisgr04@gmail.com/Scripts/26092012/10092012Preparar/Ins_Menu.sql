--select * from menu2 where padreid=6 and modulo='CONT' order by menuid 
Select * from menu2 where titulo like '%' and padreid=5 and modulo='CONT' Order by menuid
--SET DEFINE OFF;
Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('683', 'Plantillas', 'Contratos, Certificaciones (*.Doc)', '6', 1, 1, 'DatosBasicos/PPlantillas/PPlantillas.aspx', 'CONT', 'DBPPlantillas', 'N');
commit;
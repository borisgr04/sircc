delete (select *  FROM menu2 where  menuid in ('460','465','470','475','480','485','490','495') );
--select * from menu2 where padreid=4 and modulo='CONT'
Insert into MENU2 
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('460', 'Alertas Contratos', 'Vencimientos, ', '4', 1, 1, 'Reportes/Alert_Contratos/Alert_Contratos.aspx', 'CONT', 'CONTRptAlertCont', 'N');
   
Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('465', 'Estadisticas CDP ', 'Estadisticas por CDP','4', 1, 1, 'Reportes/Estadisticas/Estadisticas.aspx', 'CONT', 'CONTEstad', 'N');
   
Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('470', 'Consolidados x Mes', 'Dependencias, Modalidad, Clase', '4', 1, 1, '', 'CONT', 'CONTConsMes', 'N');   

Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('475', 'x Dependencia', 'Consolidado Mensual', '470', 1, 1, 'Reportes/Mes/MesDep/ReportPMesDep.aspx', 'CONT', 'CONTConsMes', 'N');
   
Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('480', 'x Dependencia y Clase', 'Consolidado Mensual', '470', 1, 1, 'Reportes/Mes/MesDepClas/ReportPMesDepClas.aspx', 'CONT', 'CONTConsMes', 'N');
   
Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('485', 'x Dependencia y Modalidad', 'Consolidado Mensual', '470', 1, 1, 'Reportes/Mes/MesDepMod/ReportPMesDepMod.aspx', 'CONT', 'CONTConsMes', 'N');      
Commit;

Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('490', 'F18', 'Informes del F18 - DNP', '4', 1, 1, 'Reportes/Dnp/F18/F18.aspx', 'CONT', 'CONTF18', 'N');      

Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('495', 'FUT', 'Informes del FUT - DNP', '4', 1, 1, 'Reportes/Dnp/Fut/Fut.aspx', 'CONT', 'CONTFUT', 'N');      

Commit;
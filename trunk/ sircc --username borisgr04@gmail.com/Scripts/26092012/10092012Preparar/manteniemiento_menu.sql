Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('615', 'Contratos', 'Datos Básicos Para Contratos', '6', 1, 1, '', 'CONT', 'DBContratos', 'N');

COMMIT;

Update MENU2 set padreid=615 Where MenuId In(635,645,670,680,697);



Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('612', 'Dependencias', 'Gestión de Dependencias', '6', 1, 1, '', 'CONT', 'DBDependencias', 'N');
COMMIT;

Update MENU2 set padreid=612 Where MenuId In(610,630) and modulo='CONT';
Commit;


--select * from menu2 where padreid=6 and modulo='CONT' order by menuid


Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('617', 'Legalización', 'Datos Básicos', '6', 1, 1, '', 'CONT', 'DBLegalizacion', 'N');
COMMIT;

Update MENU2 set padreid=617 Where MenuId In(655,665,691,692,693) and modulo='CONT';
Commit;

--select * from menu2 where padreid=6 and modulo='CONT' order by menuid

Insert into MENU2
   (MENUID, TITULO, DESCRIPCION, PADREID, POSICION, HABILITADO, URL, MODULO, ROLES, PPAL)
 Values
   ('624', 'Documentos', 'Datos Báscios', '6', 1, 1, '', 'CONT', 'DBDocumentos', 'N');
COMMIT;

Update MENU2 set padreid=624 Where MenuId In(683,690,695) and modulo='CONT';
Commit;
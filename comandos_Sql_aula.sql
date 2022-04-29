use comercialdb0191;

insert clientes (nome, cpf, email, datacad, ativo) values('Well Santos','11122222475','well@senac.corp',default, default);
insert clientes (nome, cpf, email, datacad, ativo) values('Adriana Santos','11133322475','adriana@senac.corp',default, default);
insert clientes (nome, cpf, email, datacad, ativo) values('Bruna Paiva','99933322475','bruna@senac.corp',default, default);

-- Store Procedure


select * from clientes;

delimiter |
CREATE PROCEDURE sp_cliente_inserir(
_nome varchar(60), 
_cpf varchar(11),
_email varchar(60)
)
BEGIN
	insert into clientes (nome,cpf, email, datacad, ativo)
    values (_nome, _cpf,_email, default, default);
    select * from clientes where idcli = (select @@identity);    
END
|



update clientes set ativo = 0 where idcli = 12;

select nome as 'seu lindo', email from clientes where idcli = 5;


select * from clientes;
delete from clientes where idcli = 11;
select * from clientes;

select * from clientes order by nome;

insert usuarios (nome, email, senha,idnv_user,ativo) 
values ('Jose', 'jose@senac.corp', md5('123456'), 4, default);
select * from usuarios;

insert usuarios (nome, email, senha,idnv_user,ativo) 
values ('Administrador', 'admin', md5('123'), 3, default);
select * from usuarios;

insert usuarios (nome, email, senha,idnv_user,ativo) 
values ('Caixa da Loja', 'cx', md5('123'), 2, default);
select * from usuarios;
update usuarios set idnv_user = 1 where iduser = 1;
delimiter |
CREATE PROCEDURE sp_cliente_usuario(
_nome varchar(60), 
_email varchar(60),
_senha varchar(32),
_idnv int
)
BEGIN
insert usuarios (nome, email, senha,idnv_user,ativo) 
values (_nome, _email, md5(_senha), _idnv, default);
    select * from usuarios where iduser = (select @@identity);    
END
|



delete from niveis where idnv between 1 and 3;  
select * from niveis;
insert niveis values(0,'Atendente', 'at'),(0,'Caixa', 'cx'),(0,'Gerente', 'gr');

call sp_produtos_inserir('Amortecedor dianteiros Kofap para Onix','par','7898846577131',376.97);

select * from clientes;

select * from pedidos;
select * from usuarios;

select * from produtos where descontinuado = 0 and descricao like '%mor%' order by 2



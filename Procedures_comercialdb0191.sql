-- Criação de Procedures 
use comercialdb0191

-- Procedure de insert cliente
-- drop PROCEDURE sp_cliente_inserir;
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

 -- Procedure Atualização clientetipos
 -- drop PROCEDURE sp_cliente_alterar;
delimiter |
CREATE PROCEDURE sp_cliente_alterar(
_id int ,
_nome varchar(60), 	
_email varchar(60)
)
BEGIN
	update clientes set nome = _nome, email = _email where idcli = _id;
END
|

-- Produtos

delimiter |
CREATE PROCEDURE sp_produtos_inserir(
_descricao varchar(100), 
_unidade varchar(14),
_codbar char(13),
_valor decimal(10,2)
)
BEGIN
insert produtos (descricao, unidade, codbar, valor,desconto,descontinuado) 
values (_descricao, _unidade, _codbar, _valor, 0, default);
    select * from produtos where idprod = (select @@identity);    
END
|

-- Usuários
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


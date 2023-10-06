CREATE TABLE enderecos (
    id_endereco SERIAL NOT NULL,
    cep VARCHAR( 50 ) NOT NULL,
    pais VARCHAR( 75 ) NOT NULL,
    estado VARCHAR( 50 ) NOT NULL,
    cidade VARCHAR( 100 ) NOT NULL,
    bairro VARCHAR( 70 ) NOT NULL,
    rua VARCHAR( 100 ) NOT NULL,
    numero VARCHAR( 20 ),
    referencias VARCHAR( 70 ),
    complementos VARCHAR( 70 ),

    CONSTRAINT pk_endereco PRIMARY KEY ( id_endereco )
);


CREATE TABLE pessoas (
    id_pessoa SERIAL NOT NULL,
    primeiro_nome VARCHAR( 50 ) NOT NULL,
    sobrenome VARCHAR( 100 ) NOT NULL,
    sexo CHAR( 2 ),
    cpf VARCHAR( 30 ) NOT NULL UNIQUE,
    fk_endereco INTEGER NOT NULL,

    CONSTRAINT pk_pessoas PRIMARY KEY ( id_pessoa ),
    FOREIGN KEY ( fk_endereco ) REFERENCES enderecos( id_endereco )
);


CREATE TABLE usuarios (
    id_usuario SERIAL NOT NULL,
    email VARCHAR( 150 ) NOT NULL UNIQUE,
    senha VARCHAR( 150 ) NOT NULL,

    fk_pessoa INTEGER NOT NULL,

    CONSTRAINT pk_usuario PRIMARY KEY ( id_usuario ),
    FOREIGN KEY ( fk_pessoa ) REFERENCES pessoas( id_pessoa )
);

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Clientes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` VARCHAR(80) CHARACTER SET utf8mb4 NOT NULL,
    `Telefone` CHAR(11) CHARACTER SET utf8mb4 NULL,
    `Cep` CHAR(8) CHARACTER SET utf8mb4 NOT NULL,
    `Estado` CHAR(2) CHARACTER SET utf8mb4 NOT NULL,
    `Cidade` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Clientes` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Produtos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CodigoBarras` VARCHAR(14) CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` VARCHAR(60) CHARACTER SET utf8mb4 NULL,
    `Valor` decimal(65,30) NOT NULL,
    `TipoProduto` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Pedidos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `IniciadoEm` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `FinalizadoEm` datetime(6) NOT NULL,
    `TipoFrete` int NOT NULL,
    `Status` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Observacao` VARCHAR(512) CHARACTER SET utf8mb4 NULL,
    `ClienteId` int NOT NULL,
    CONSTRAINT `PK_Pedidos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Pedidos_Clientes_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `Clientes` (`Id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE TABLE `PedidoItens` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Valor` decimal(65,30) NOT NULL,
    `Desconto` decimal(65,30) NOT NULL,
    `Quantidade` int NOT NULL DEFAULT 1,
    `PedidoId` int NOT NULL,
    `ProdutoId` int NOT NULL,
    CONSTRAINT `PK_PedidoItens` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PedidoItens_Pedidos_PedidoId` FOREIGN KEY (`PedidoId`) REFERENCES `Pedidos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_PedidoItens_Produtos_ProdutoId` FOREIGN KEY (`ProdutoId`) REFERENCES `Produtos` (`Id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE INDEX `idx_cliente_telefone` ON `Clientes` (`Telefone`);

CREATE INDEX `IX_PedidoItens_PedidoId` ON `PedidoItens` (`PedidoId`);

CREATE INDEX `IX_PedidoItens_ProdutoId` ON `PedidoItens` (`ProdutoId`);

CREATE INDEX `IX_Pedidos_ClienteId` ON `Pedidos` (`ClienteId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220309185134_PrimeiraMigracao', '5.0.14');

COMMIT;


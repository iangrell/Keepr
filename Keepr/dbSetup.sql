CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8mb4 COMMENT '';

ALTER TABLE accounts ADD COLUMN coverImg VARCHAR(255);

-- SECTION KEEPS

CREATE TABLE
    keeps(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        description VARCHAR(1020) NOT NULL,
        img VARCHAR(1020) NOT NULL,
        views INT NOT NULL DEFAULT 0,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

ALTER TABLE keeps ADD COLUMN kept INT NOT NULL DEFAULT 0;

INSERT INTO
    keeps(
        name,
        description,
        img,
        creatorId
    )
VALUES (
        'Bourbon',
        'Woodford',
        'https://images.unsplash.com/photo-1608471250290-f7d6b569ff46?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80',
        '642caa25c178a672b1f898d2'
    );

-- SECTION VAULTS

CREATE TABLE
    vaults(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        description VARCHAR(1020),
        img VARCHAR(1020) NOT NULL,
        isPrivate BOOLEAN NOT NULL DEFAULT false,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

-- SECTION VAULTKEEPS

CREATE TABLE
    vaultKeeps(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        keepId INT NOT NULL,
        vaultId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';
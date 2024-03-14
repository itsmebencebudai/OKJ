// /// <reference types="cypress" />

// import mysql, { Pool, PoolOptions } from 'mysql2/promise';

// const poolOptions: PoolOptions = {
//     host: 'localhost',
//     user: 'rppt',
//     password: '',
//     database: 'chat',
//     connectionLimit: 10
// };

// const pool: Pool = mysql.createPool(poolOptions);

// declare global {
//     namespace Cypress {
//         interface Chainable {
//             deleteUserFromMySQL(userId: string): Chainable<void>;
//         }
//     }
// }

// Cypress.Commands.add('deleteUserFromMySQL', (userId: string) => {
//     return cy.wrap(new Promise<void>(async (resolve, reject) => {
//         let connection;
//         try {
//             connection = await pool.getConnection();

//             const [rows, fields] = await connection.execute('DELETE FROM user WHERE email = ?', [userId]);
//             console.log(`Deleted ${rows.affectedRows} user`);
//             resolve();
//         } catch (error) {
//             console.error('Error deleting user:', error);
//             reject(error);
//         } finally {
//             if (connection) {
//                 connection.release();
//             }
//         }
//     }));
// });



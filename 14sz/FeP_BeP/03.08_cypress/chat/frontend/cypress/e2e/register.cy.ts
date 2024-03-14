/// <reference types="cypress" />
describe('Registration page', () => {

  const useremail = 'maci@laci2.com'
  const wronguseremail = 'macilaci2.com'
  const userpassword = 'macika2'
  const username = 'Macika2'

  beforeEach(() => {
    cy.visit('http://localhost:5173/')
    cy.get('.right').click()
  });

  it('Nagyszerű URL', () => {
    cy.url().should('eq', 'http://localhost:5173/signup')
  })

  it('Nincsen felhasználónév', () => {
    cy.get('[type="text"]').type(username)
    cy.get('[type="email"]').type(useremail)
    cy.get('[placeholder="Jelszó"]').type(userpassword)
    cy.get('[placeholder="Jelszó ismét"]').type(userpassword)
    cy.get('#upload').selectFile('../frontend/logo.png')
    cy.get('.signup-button').click()
    cy.url().should('eq', 'http://localhost:5173/signup')
  })

  it('Rossz emailcím', () => {
    cy.get('[type="text"]').type(username)
    cy.get('[type="email"]').type(wronguseremail)
    cy.get('[placeholder="Jelszó"]').type(userpassword)
    cy.get('[placeholder="Jelszó ismét"]').type(userpassword)
    cy.get('#upload').selectFile('../frontend/logo.png')
    cy.get('.signup-button').click()
    cy.get('[type="email"]').invoke('val').should('not.include', '@');
    cy.url().should('eq', 'http://localhost:5173/signup')
  })
});


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

  it('User can register', () => {
    cy.get('[type="text"]').type(username)
    cy.get('[type="email"]').type(useremail)
    cy.get('[placeholder="Jelszó"]').type(userpassword)
    cy.get('[placeholder="Jelszó ismét"]').type(userpassword)
    cy.get('#upload').selectFile('../frontend/logo.png')
    cy.get('[type="submit"]').click()
    
    // cy.url().should('eq', 'http://localhost:5173/')
  })

  it('Can go from Reg to Log', () => {
    cy.get('[type="button"]').click()
    cy.url().should('eq', 'http://localhost:5173/')
  })

  it('Rossz emailcím', () => {
    cy.get('[type="text"]').type(username)
    cy.get('[type="email"]').type(wronguseremail)
    cy.get('[placeholder="Jelszó"]').type(userpassword)
    cy.get('[placeholder="Jelszó ismét"]').type(userpassword)
    cy.get('#upload').selectFile('../frontend/logo.png')
    cy.get('[type="submit"]').click()
    cy.get('[type="email"]').invoke('val').should('not.include', '@');
    cy.url().should('eq', 'http://localhost:5173/signup')
  })

  it('User can register and login', () => {
    cy.get('[type="text"]').type(username)
    cy.get('[type="email"]').type(useremail)
    cy.get('[placeholder="Jelszó"]').type(userpassword)
    cy.get('[placeholder="Jelszó ismét"]').type(userpassword)
    cy.get('#upload').selectFile('../frontend/logo.png')
    cy.get('[type="submit"]').click()
    cy.url().should('eq', 'http://localhost:5173/')
    cy.get('input[type=email]').type(useremail)
    cy.get('input[type=password]').type(userpassword)
    cy.get('button.login-button').click()
    cy.url().should('eq', 'http://localhost:5173/chat')
  })
});


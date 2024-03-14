/// <reference types="cypress" />

describe('Login page', () => {

  const useremail = 'maci@laci.com'
  const userpassword = 'macika'
  const wrongpassword = 'bucika'
  const wrongemail = 'maci@laci.hu'

  beforeEach(() => {
    cy.visit('http://localhost:5173/chat')
  });

  it('Great url', () => {
    cy.url().should('eq', 'http://localhost:5173/')
  })

  it('Successfull login', () => {
    cy.get('input[type=email]').type(useremail)
    cy.get('input[type=password]').type(userpassword)
    cy.get('button.login-button').click()
    cy.url().should('eq', 'http://localhost:5173/chat')
  });

  it('Open registration', () => {
    cy.get('a').contains('Regisztráció').click()
    cy.url().should('eq', 'http://localhost:5173/signup')
  });

  it('Wrong login data SWAL - wrong password', () => {
    cy.get('input[type=email]').type(useremail)
    cy.get('input[type=password]').type(wrongpassword)
    cy.get('button').contains('Login').click()
    cy.get('.swal2-container').should('be.visible')
    cy.get('.swal2-title').should('have.text', 'Hiba')
    cy.get('#swal2-content').should('have.text', 'Error: Nem engedélyezett!')
    cy.get('.swal2-confirm').should('have.text', 'OK')
    cy.get('.swal2-confirm').click()
    cy.get('.swal2-container').should('not.exist')
  });

  it('Wrong login data SWAL - wrong email', () => {
    cy.get('input[type=email]').type(wrongemail)
    cy.get('input[type=password]').type(userpassword)
    cy.get('button').contains('Login').click()
    cy.get('.swal2-container').should('be.visible')
    cy.get('.swal2-title').should('have.text', 'Hiba')
    cy.get('#swal2-content').should('have.text', 'Error: Nem engedélyezett!')
    cy.get('.swal2-confirm').should('have.text', 'OK')
    cy.get('.swal2-confirm').click()
    cy.get('.swal2-container').should('not.exist')
  });

  it('Üres login SWAL', () => {
    cy.get('button').contains('Login').click()
    cy.get('.swal2-modal').should('be.visible')
    cy.get('#swal2-title').should('have.text', 'Hiba...')
    cy.get('#swal2-content').should('have.text', 'Töltsd ki az adatokat megfelelően!')
    cy.get('.swal2-confirm').should('have.text', 'OK')
    cy.get('.swal2-confirm').click()
    cy.get('.swal2-modal').should('not.exist')
  })
})

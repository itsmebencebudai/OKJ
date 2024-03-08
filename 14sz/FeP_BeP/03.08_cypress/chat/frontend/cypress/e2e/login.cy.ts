/// <reference types="cypress" />
describe('Login page', () => {

  const useremail = 'maci@laci.com'
  const userpassword = 'macika'
  const wrongpassword = 'bucika'
  const worngemail = 'maci@laci.hu'

  beforeEach(() => {
    cy.visit('http://localhost:5173/chat')
  });
  it('Helyes url betöltés ha nincs bejelentkezés', () => {
    cy.url().should('eq', 'http://localhost:5173/')
  })
  it('Hiba a bejelentkezéskor', () => {
    cy.get('input[type=email]')
      .type(useremail)
    cy.get('input[type=password]')
      .type(userpassword)
    cy.get('button')
      .contains('Login')
      .click()
    cy.url().should('eq', 'http://localhost:5173/chat')
  });

  it('Regisztració megnyitása', () => {
    cy.get('a')
      .contains('Regisztráció')
      .click()
    cy.url().should('eq', 'http://localhost:5173/signup')
  });

  it('Hiba a bejelentkezéskor SWAL', () => {
    cy.get('input[type=email]')
      .type(worngemail)
    cy.get('input[type=password]')
      .type(wrongpassword)
    cy.get('button')
      .contains('Login')
      .click()
    cy.get('.swal2-container').should('be.visible')
    cy.get('.swal2-title').should('have.text', 'Hiba')
    cy.get('#swal2-content').should('have.text', 'Error: Nem engedélyezett!')
    cy.get('.swal2-confirm').should('have.text', 'OK')
    cy.get('.swal2-confirm').click()
    cy.get('.swal2-container').should('not.exist')
  });

  it('Hiba nem beírt bejelentkezésnél SWAL', () => {
    cy.get('button')
      .contains('Login')
      .click()
    cy.get('.swal2-modal').should('be.visible')
    cy.get('#swal2-title').should('have.text', 'Hiba...')
    cy.get('#swal2-content').should('have.text', 'Töltsd ki az adatokat megfelelően!')
    cy.get('.swal2-confirm').should('have.text', 'OK')
    cy.get('.swal2-confirm').click()
    cy.get('.swal2-modal').should('not.exist')
  })
})

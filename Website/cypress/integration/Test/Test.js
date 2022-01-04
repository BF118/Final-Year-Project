/// <reference types="cypress" />
///https://on.cypress.io/introduction-to-cypress

describe('Final Year Project', () => {
    beforeEach(() => {
        cy.visit('http://bf118.webhosting.canterbury.ac.uk/')
    })

    it('can see four encounter Buttons', () => {

        cy.get('button').contains('Encounter1')
        cy.get('button').contains('Encounter2')
        cy.get('button').contains('Encounter3')
        cy.get('button').contains('Encounter4')
    })

    it('Clicks encounter 1 and 4 buttons', () => {
        cy.get('button').contains('Encounter1').click()
        cy.get('button').contains('Encounter4').click()
    })

    it('Create signup updates sheet', () => {


        cy.get('textarea').should('have.value', 'Test Sheet')
        cy.get('button').contains('Create Signup').click()

        cy.get('textarea').should('have.value', 'Updated')
    })
    it('Open Discord invite', () => {
        cy.get('[alt="Discord"]').invoke('removeAttr', 'target').click()
    })
})

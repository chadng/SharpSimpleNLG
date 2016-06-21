/*
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations
 * under the License.
 *
 * The Original Code is "SharpSimpleNLG".
 *
 * The Initial Developer of the Original Code is Ehud Reiter, Albert Gatt and Dave Westwater.
 * Portions created by Ehud Reiter, Albert Gatt and Dave Westwater are Copyright (C) 2010-11 The University of Aberdeen. All Rights Reserved.
 *
 * Contributor(s): Ehud Reiter, Albert Gatt, Dave Wewstwater, Roman Kutlak, Margaret Mitchell, Saad Mahamood, Nick Hodge
 */

/* Additional Notes:
 *    - Original Java source is SimpleNLG from 12-Jun-2016 https://github.com/simplenlg/simplenlg
 *    - This is a port of the Java version to C# with no additional features
 *    - I have left the "Initial Developer" section to reflect this fact
 *    - Any questions, comments, feedback on this port can be sent to Nick Hodge <nhodge@mungr.com>
 */

namespace SimpleNLG
{
    public enum InternalFeature
    {
        /**
         * <p>
         * This feature determines if the element is an acronym.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>isAcronym</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>Boolean</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The phrase factory creates the feature on noun phrases. The syntax
         * processor creates the feature on nouns.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>No processors currently use this feature. It is expected to be used
         * by the orthography processor.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Nouns and noun phrases.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>Boolean.FALSE</code></td>
         * </tr>
         * </table>
         */
        ACRONYM = 1000,// = "acronym";
                       /**
                        * <p>
                        * This feature is used to reference the base word element as created by the
                        * lexicon.
                        * </p>
                        * <table border="1">
                        * <tr>
                        * <td><b>Feature name</b></td>
                        * <td><em>baseWord</em></td>
                        * </tr>
                        * <tr>
                        * <td><b>Expected type</b></td>
                        * <td><code>WordElement</code></td>
                        * </tr>
                        * <tr>
                        * <td><b>Created by</b></td>
                        * <td>Currently initially set by the syntax processor but should be done by
                        * the phrase factory with the syntax and morphology processors only setting
                        * this if the it doesn't already exist.</td>
                        * </tr>
                        * <tr>
                        * <td><b>Used by</b></td>
                        * <td>The syntax processor refers to the base word when determining
                        * adjective ordering. The morphology processor also needs the base word for
                        * performing morphology on the lexical items.</td>
                        * </tr>
                        * <tr>
                        * <td><b>Applies to</b></td>
                        * <td><code>InflectedWordElement</code>s of any category.</td>
                        * </tr>
                        * <tr>
                        * <td><b>Default</b></td>
                        * <td><code>null</code></td>
                        * </tr>
                        * </table>
                        */
        BASE_WORD = 1001,// = "base_word";
        /**
         * <p>
         * This feature determines the status of a sentence.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>clauseStatus</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>ClauseStatus</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The phrase factory creates this feature when creating sentences.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor refers to the clause status when deciding
         * whether to add the complementiser or not. Only subordinate clauses will
         * have the complementiser added.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Clauses.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>ClauseStatus.MATRIX</code></td>
         * </tr>
         * </table>
         */
        CLAUSE_STATUS = 1002,// = "clause_status";
                             /**
                              * <p>
                              * This feature refers to the list of complements for the phrase.
                              * </p>
                              * <table border="1">
                              * <tr>
                              * <td><b>Feature name</b></td>
                              * <td><em>complements</em></td>
                              * </tr>
                              * <tr>
                              * <td><b>Expected type</b></td>
                              * <td><code>List&lt;NLGElement&gt;</code></td>
                              * </tr>
                              * <tr>
                              * <td><b>Created by</b></td>
                              * <td>The phrase factory has the functionality for taking complements when
                              * creating prepositional phrases or sentences. Complements can also be
                              * added to other types of phrases by the user.</td>
                              * </tr>
                              * <tr>
                              * <td><b>Used by</b></td>
                              * <td>The syntax processor realises the complements in the correct
                              * syntactical order when realising phrases.</td>
                              * </tr>
                              * <tr>
                              * <td><b>Applies to</b></td>
                              * <td>Phrases of any type.</td>
                              * </tr>
                              * <tr>
                              * <td><b>Default</b></td>
                              * <td><code>ClauseStatus.MATRIX</code></td>
                              * </tr>
                              * </table>
                              */
        COMPLEMENTS = 1004,// = "complements";
        /**
         * <p>
         * This feature refers to the list of components in a
         * <code>ListElement</code>.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>components</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>List&lt;NLGElements&gt;</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The syntax processor creates <code>ListElement</code>s with
         * components. This is done as part of the normal realisation of phrases
         * into a list of words. Components can be added by the user.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax and morphology processors both access the components
         * feature when realising <code>ListElement</code>s.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td><code>ListElement</code>s.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code></td>
         * </tr>
         * </table>
         */
        COMPONENTS = 1005,// = "components";
        /**
         * <p>
         * This feature is the list of coordinated phrases in a
         * <code>CoordinatedPhraseElement</code>.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>coordinates</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>List&lt;NLGElements&gt;</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td><code>CoordinatedPhraseElement</code> has convenience methods for
         * adding the coordinate phrases to a particular.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processors creates the structure of coordinated phrases
         * and adds in the conjoining word where appropriate.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td><code>CoordinatedPhraseElements</code>s only.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code></td>
         * </tr>
         * </table>
         */
        COORDINATES = 1006,// = "coordinates";
                           /**
                            * <p>
                            * This feature defines the role each element plays in the structure of the
                            * text. For example, the phrase <em>John played football</em> has
                            * <em>John</em> as the subject, <em>play</em> as the base verb and
                            * <em>football</em> as the complement.
                            * </p>
                            * <table border="1">
                            * <tr>
                            * <td><b>Feature name</b></td>
                            * <td><em>discourseFunction</em></td>
                            * </tr>
                            * <tr>
                            * <td><b>Expected type</b></td>
                            * <td><code>DiscourseFunction</code></td>
                            * </tr>
                            * <tr>
                            * <td><b>Created by</b></td>
                            * <td>The syntax processor defines the function of each word as it parses
                            * phrases.</td>
                            * </tr>
                            * <tr>
                            * <td><b>Used by</b></td>
                            * <td>The morphology processor uses the function when checking pronoun
                            * inflections.</td>
                            * </tr>
                            * <tr>
                            * <td><b>Applies to</b></td>
                            * <td>Any NLGElement but typically words.</td>
                            * </tr>
                            * <tr>
                            * <td><b>Default</b></td>
                            * <td><code>null</code></td>
                            * </tr>
                            * </table>
                            */
        DISCOURSE_FUNCTION = 1007,// = "discourse_function";

        NON_MORPH = 1008,// = "non_morph";
        /**
         * <p>
         * This feature tracks any front modifiers in sentences. Front modifiers are
         * placed after the cue phrase but before the subject.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>frontModifiers</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>NLGElement</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>Front modifiers need to be manually added by users.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor realises front modifiers in their correct place
         * within the structure of the sentence.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Sentences.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code></td>
         * </tr>
         * </table>
         */
        FRONT_MODIFIERS = 1010,// = "front_modifiers";
        /**
         * <p>
         * This feature points to the head element in a phrase. The head element is
         * deemed to be the subject in a noun phrase, the verb in a verb phrase, the
         * adjective in an adjective phrase, the adverb in an adverb phrase or the
         * preposition in a preposition phrase. The <code>PhraseElement</code> has a
         * convenience method for getting and setting the head feature.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>phraseHead</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>NLGElement</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The phrase factory sets an appropriate head when constructing
         * phrases.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor uses the head element when constructing the
         * correct syntax for the text. The head element is also important for
         * determining the main verb in a verb group.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Phrases.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td>The value is set to an appropriate element by the phrase factory.</td>
         * </tr>
         * </table>
         */
        HEAD = 1011,// = "head";
                    /**
                     * <p>
                     * This flag is used to determine if the modal should be included in the
                     * verb phrase.
                     * </p>
                     * <table border="1">
                     * <tr>
                     * <td><b>Feature name</b></td>
                     * <td><em>ignoreModal</em></td>
                     * </tr>
                     * <tr>
                     * <td><b>Expected type</b></td>
                     * <td><code>Boolean</code></td>
                     * </tr>
                     * <tr>
                     * <td><b>Created by</b></td>
                     * <td>The syntax processor sets this flag when dealing with interrogatives.
                     * </td>
                     * </tr>
                     * <tr>
                     * <td><b>Used by</b></td>
                     * <td>The syntax processor will ignore modals on certain interrogatives.</td>
                     * </tr>
                     * <tr>
                     * <td><b>Applies to</b></td>
                     * <td>Coordinated phrases and verb phrases.</td>
                     * </tr>
                     * <tr>
                     * <td><b>Default</b></td>
                     * <td><code>Boolean.FALSE</code></td>
                     * </tr>
                     * </table>
                     */
        IGNORE_MODAL = 1012,// = "ignore_modal";
        /**
         * <p>
         * This flag determines if the sentence is interrogative or not.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>isInterrogative</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>Boolean</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The syntax processor sets this feature on sentences if a contained
         * phrase is interrogative.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>Orthography processor uses this to add a question mark instead of a
         * period at the end of interrogative sentences.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Sentences only.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>Boolean.FALSE</code>.</td>
         * </tr>
         * </table>
         */
        INTERROGATIVE = 1013,// = "interrogative";
        /**
         * <p>
         * This feature represents the list of post-modifier elements.
         * Post-modifiers are added to the end of phrases and coordinated phrases.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>postModifiers</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>List&lt;NLGElement&gt;</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The user specifies the post-modifiers. Convenience methods are added.
         * </td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor correctly adds the post-modifiers into the
         * structure of the text.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Clauses, phrases and coordinated phrases.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code>.</td>
         * </tr>
         * </table>
         */
        POSTMODIFIERS = 1014,// = "postmodifiers";
        /**
         * <p>
         * This feature represents the list of premodifier elements. Premodifiers
         * are added to phrases before the head of the phrase, and to coordinated
         * phrases before the coordinates.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>preModifiers</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>List&lt;NLGElement&gt;</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The user specifies the premodifiers. Convenience methods are added.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor correctly adds the premodifiers into the
         * structure of the text.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Clauses, phrases and coordinated phrases.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code>.</td>
         * </tr>
         * </table>
         */
        PREMODIFIERS = 1015,// = "premodifiers";
        /**
         * <p>
         * This flag is used to define whether a noun phrase has had its specifier
         * raised. It is used in conjunction with the <code>RAISE_SECIFIER</code>
         * feature.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>isRaised</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>Boolean</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>The syntax processor sets this flag on noun phrases when processing
         * coordinated phrases whose specifier has been raised.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor to correctly add or remove specifiers.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Noun phrases only.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>Boolean.FALSE</code></td>
         * </tr>
         * </table>
         */
        RAISED = 1016,// = "raised";
                      /**
                        * <p>
                        * This flag determines if auxiliary verbs should be realised in coordinated
                        * verb phrases.
                        * </p>
                        * <table border="1">
                        * <tr>
                        * <td><b>Feature name</b></td>
                        * <td><em>isRealiseAuxiliary</em></td>
                        * </tr>
                        * <tr>
                        * <td><b>Expected type</b></td>
                        * <td><code>Boolean</code></td>
                        * </tr>
                        * <tr>
                        * <td><b>Created by</b></td>
                        * <td>The syntax processor sets this flag on verb phrases when processing
                        * coordinated phrases which has had the <code>AGGREGATE_AUXILIARY</code>
                        * feature set.</td>
                        * </tr>
                        * <tr>
                        * <td><b>Used by</b></td>
                        * <td>The syntax processor to correctly add or ignore auxiliary verbs in
                        * verb phrases.</td>
                        * </tr>
                        * <tr>
                        * <td><b>Applies to</b></td>
                        * <td>Verb phrases only.</td>
                        * </tr>
                        * <tr>
                        * <td><b>Default</b></td>
                        * <td><code>Boolean.FALSE</code></td>
                        * </tr>
                        * </table>
                        */
        REALISE_AUXILIARY = 1017,// = "realise_auxiliary";
        /**
         * <p>
         * This feature contains the specifier for a noun phrase. For example
         * <em>the</em> and <em>my</em>.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>specifier</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>NLGElement</code> or <code>string</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>Specifiers are added to noun phrases when they are constructed by the
         * phrase factory.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor places specifiers before the main subject in a
         * noun phrase.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Noun phrases only.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code></td>
         * </tr>
         * </table>
         */
        SPECIFIER = 1018,// = "specifier";
        /**
         * <p>
         * This feature represents the list of subjects in a clause.
         * </p>
         * <table border="1">
         * <tr>
         * <td><b>Feature name</b></td>
         * <td><em>subjects</em></td>
         * </tr>
         * <tr>
         * <td><b>Expected type</b></td>
         * <td><code>List&lt;NLGElement&gt;</code></td>
         * </tr>
         * <tr>
         * <td><b>Created by</b></td>
         * <td>Subjects are added to clauses through the phrase factory.</td>
         * </tr>
         * <tr>
         * <td><b>Used by</b></td>
         * <td>The syntax processor realises all subjects in the correct place.</td>
         * </tr>
         * <tr>
         * <td><b>Applies to</b></td>
         * <td>Clauses only.</td>
         * </tr>
         * <tr>
         * <td><b>Default</b></td>
         * <td><code>null</code>.</td>
         * </tr>
         * </table>
         */
        SUBJECTS = 1019,// = "subjects";
                        /**
                         * <p>
                         * This feature represents the verb phrase in a clause.
                         * </p>
                         * <table border="1">
                         * <tr>
                         * <td><b>Feature name</b></td>
                         * <td><em>verbPhrase</em></td>
                         * </tr>
                         * <tr>
                         * <td><b>Expected type</b></td>
                         * <td><code>NLGElement</code>, typically a <code>PhraseElement</code>, but
                         * can also be a <code>string</code></td>
                         * </tr>
                         * <tr>
                         * <td><b>Created by</b></td>
                         * <td>The verb phrase is added to clauses through the phrase factory.</td>
                         * </tr>
                         * <tr>
                         * <td><b>Used by</b></td>
                         * <td>The syntax processor realises the verb phrase in the correct place.</td>
                         * </tr>
                         * <tr>
                         * <td><b>Applies to</b></td>
                         * <td>Clauses only.</td>
                         * </tr>
                         * <tr>
                         * <td><b>Default</b></td>
                         * <td><code>null</code>.</td>
                         * </tr>
                         * </table>
                         */
        VERB_PHRASE = 1020,// = "verb_phrase";

    }

     public static class InternalFeatureExtensions
     {
         public static string ToString(this InternalFeature intf)
         {
             switch (intf)
             {
                 case InternalFeature.ACRONYM:
                     return "acronym";
                 case InternalFeature.BASE_WORD:
                     return "base_word";
                 case InternalFeature.CLAUSE_STATUS:
                     return "clause_status";
                 case InternalFeature.COMPLEMENTS:
                     return "complements";
                 case InternalFeature.COMPONENTS:
                     return "components";
                 case InternalFeature.COORDINATES:
                     return "coordinates";
                 case InternalFeature.DISCOURSE_FUNCTION:
                     return "discourse_function";
                 case InternalFeature.NON_MORPH:
                     return "non_morph";
                 case InternalFeature.FRONT_MODIFIERS:
                     return "front_modifiers";
                 case InternalFeature.HEAD:
                     return "head";
                 case InternalFeature.IGNORE_MODAL:
                     return "ignore_modal";
                 case InternalFeature.INTERROGATIVE:
                     return "interrogative";
                 case InternalFeature.POSTMODIFIERS:
                     return "postmodifiers";
                 case InternalFeature.PREMODIFIERS:
                     return "premodifiers";
                 case InternalFeature.RAISED:
                     return "raised";
                 case InternalFeature.REALISE_AUXILIARY:
                     return "realise_auxiliary";
                 case InternalFeature.SPECIFIER:
                     return "specifier";
                 case InternalFeature.SUBJECTS:
                     return "subjects";
                 case InternalFeature.VERB_PHRASE:
                     return "verb_phrase";
                 default:
                     return "";
             }
         }
     }
}
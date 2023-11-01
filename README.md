# BLS ARS

This repository tracks the Unity project files for the Basic Life Support Augmented Reality Simulator (BLS ARS) 3D mid-fidelity prototype and AR technology probe. It is developed by Ayla Gunawan for the Townsville Adult and Pediatric Sonography and Education Incorporate (TAPSE Inc.) as part of CP3103 Independent Project work-integrated learning (WIL) subject at James Cook University (JCU).

## Introduction

This project will involve designing and developing an Augmented Reality (AR) game application for Basic Life Support (BLS) training. By simulating BLS scenarios over a live camera, it equips users with the knowledge and skills to perform the DRSABCD action plan in different emergency situations, including CPR (cardiopulmonary resuscitation). It is made to be both a teaching and supervising tool where players can learn in a flexible and interactive environment.

## Background

Technology in the field of medicine is constantly evolving to keep up with current health practice, but tools for training and simulation are still largely underdeveloped. When learning about BLS, health workers are asked to “use their imagination” and conduct simulations with equipment like manikins. Although it is effective for teaching the process, it does not engage them in real-world situations. Likewise, the market for Extended Reality (XR) is projected to increase exponentially over the next decade, reaching US$345.9B by 2030 [1], but its share in education and medical industries leaves much to be desired. This project aims to solve these issues by introducing AR into the health learning space, not as a replacement of current BLS practice but as a digital aid.

## Objectives

Following the SMART framework, the objectives of this project were as follows:
* _To present a proof-of-concept where the full BLS process can be translated into a digital environment by the end of the project timeline.
This objective is specific, achievable by the designer and realistically within resources. It will be measured by the completeness of the DRSABCD action plan in the final product. The timing is within 100 hours over Study Period 2 2023, Week 3 to 13. This contributes to the workplace of TAPSE by verifying the project’s feasibility for further development._
* _To produce a functional prototype that satisfies the workplace supervisor’s requirements by the end of the project timeline.
This objective is specific, achievable by the designer and realistically within resources. It will be measured by the fulfilment of the project outcomes below. The timing is as above. This contributes to TAPSE by making a workable foundation that can be built upon later._
* _To demonstrate that AR can bring value to pre-established medical training procedures via immersion and gamification by the end of the project timeline.
This objective is specific, achievable by the designer and realistically within resources. It will be measured by product satisfaction in the user testing. The timing is as above. This contributes to TAPSE by promoting the possibilities of AR in health education._

## Project Outcomes

As discussed with the supervisor, the outcomes of this project were as follows verbatim:
* _To satisfy the vision of the client at an acceptable quality_
* _To produce a prototype which reflects the concept_
* _To bring value to the workplace through AR technology_

## Learning Outcomes

Following Bloom’s Taxonomy, the learning outcomes of this project were as follows:
* _By the end of this project, the student will be able to demonstrate proficiency in game development, version control and AR technologies._
* _By the end of this project, the student will be able to demonstrate understanding of the BLS process and develop a product based on its concepts._
* _By the end of this project, the student will be able to demonstrate proficiency in project management, communication and best practices._

## Company Benefits

The advantages gained by the chosen workplace from this project were as follows:
* _The facilitation of BLS simulation in an immersive environment to enhance engagement and effectiveness of TAPSE Inc.’s services._
* _The illumination and exploration of TAPSE Inc.’s potential research opportunities in the Augmented Reality (AR) space and other areas._
* _The expansion and economic growth of TAPSE Inc. as the region’s forefront of emerging technology in medicine with  an untapped market._

## Scope

The scope below is achievable within the 100-hour limit. It considers the skillset and schedule of the designer and has been reviewed by the workplace supervisor.

### Deliverables
The product deliverables of this project are as follows:
* A low-fidelity prototype in any media (2D)
* A mid-fidelity prototype made in Unity (3D)
* A technology probe made in Unity (AR)

The documentation deliverables of this project are as follows:
* A project proposal and presentation
* A project progress presentation
* A project report and presentation
* A workplace supervisor appraisal report

### Inclusions
Elements inside the scope of this project are as follows:
* The functionality of the product (controls, game loop, performance evaluation)
* The inclusion of content (accurate DRSABCD, at least one (1) game scenario)
* The immersion of visuals (realistic art direction, assets, user interface)

### Exclusions
Elements outside the scope of this project are as follows:
* The deployment and distribution of the product
* The portability across multiple mobile platforms
* The scalability of game features (i.e. randomisation/customisation, multiplayer)

### Constraints
Factors that may limit the scope of this project are as follows:
* Unforeseen timing difficulties
* Unforeseen technological difficulties
* Insufficient research/resources for AR concepts

### Assumptions
Factors expected for the scope of this project are as follows:
* There are no budget conditions proposed by the workplace supervisor
* There are no payment conditions proposed by the designer
* Upon project completion, the designer will own the patent to the product

## Final Outcome Summaries

### Mid-Fidelity Prototype

The second project milestone was a 3D first-person game constructed in Unity. This prototype was to set up the foundations of a proof-of-concept with minimum product functionality, content and visuals as per the scope. It consists of the game loop, player controls, object interactions using raycasts on layer masks, UI, placeholder assets and sound effects. There are scenes for the menu and the first stage. The BLS process manifests itself through accurate DRSABCD representation, one (1) in-game scenario translated from the low-fidelity version, and a working evaluation algorithm (in the StageManager). This dynamically displays interactions the player made and/or missed, and whether they are in the correct order or not. The immersiveness was captured by the realistic art direction of the three-dimensional models, textures, lighting and reproduction of setting (i.e. a moving car). To avoid the risk of data corruption and loss, version control was done with Git and GitHub. However, many technical challenges were encountered with speech-to-text operations (repaired using the whisper.unity module) and animations.

User testing was conducted with two (2) anonymous users, with backgrounds in medicine and game development respectively, to gain insight and critique. Their initial impressions were both positive, appreciating the novelty and presentation of the current but proposed various changes in BLS integration and game mechanics. For example, visual feedback after interacting with an object would increase intuitiveness, and the defibrillator should only appear when an ambulance arrives, else the BLS process becomes redundant. Their suggestions are to be added in future iterations. At this point, the third milestone was pivoted from a high-fidelity to a technology probe to align with the focus on feasibility.

### Technology Probe

The third and final project milestone was an AR technology study and probe performed in Unity. The intention of this prototype was to establish a solid basis of research and tests in Augmented Reality. Doing so ensures that the project is viable for continuation and marketing. First, AR was investigated in a SWOT Analysis, as well as the issue of AR cybersickness and its differences to VR in terms of symptoms/remedies. Potential ways to expand were also explored: performance evaluation with AI, online compatibility, multiplayer and large-scale disasters. Then a probe was conducted, where an experimental AR app was compiled and built to Android (Samsung Galaxy A73). It contains Unity packages for AR support setup, including objects like XR Origins and AR Planes, and a human model to represent a game element. This is overlaid atop the device’s live footage to give the impression that it exists in reality. Its validity was judged upon acceptance criteria: functionality, readability, responsiveness and BLS integration. Technical challenges arose in the form of inability to port to iOS.

There was notable feedback for this milestone. The probe tests could be more comprehensive, for instance verifying different phone devices, OS, physical environments and lighting conditions (i.e. in shade). Virtual hands or transparency could be incorporated to enhance the readability of in-game objects when the user’s hands are in front, as well as transferring the BLS mechanics from the mid-fidelity prototype into the probe to confirm that it functions as expected. QR codes could also be employed to dictate the positioning of elements, especially when overlapping with real-world equipment such as a dummy. In addition, the solution strategy’s Waterfall model was customised to facilitate Agile/Lean UX incrementation.
